using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomMeshGenerator : MonoBehaviour {

    /*
     * This function will create a 2D wedge mesh
     * 
     * Parameters:
     * numEdgePoints: The number of points to create around the edge of the wedge, more points means a smoother wedge, but also more triangles and slower rendering
     * radius: The radius of the circle we're cutting a wedge from
     * angle: How much of a circle you want your wedge to cover in degrees. 360 degrees will create a circle.
     * 
     * Returns:
     * wedgeMesh: The mesh of the wedge
     */
    public static Mesh Create2DWedge(int numEdgePoints, float radius, float angle, bool facingForward=true)
    {
        Mesh wedgeMesh = new Mesh();

        Vector3[] vertices = new Vector3[numEdgePoints + 2];
        int[] tri = new int[numEdgePoints * 3];

        // Center point
        vertices[0] = new Vector3(0f, 0f, 0f);

        // Create the points around the circle
        for (int i = 0; i <= numEdgePoints; i++)
        {
            // NOTE: SIN and COS expect radians!
            vertices[i+1] = new Vector3(Mathf.Cos(i * (angle / numEdgePoints) * Mathf.Deg2Rad) * radius, Mathf.Sin(i * (angle / numEdgePoints) * Mathf.Deg2Rad) * radius, 0f);
        }

        for (int i = 0; i <= numEdgePoints - 2; i++)
        {
            // If we want the circle facing forward (towards -Z), we build the triangles in a different order than if we want it facing backwards (towards +Z)
            if (facingForward)
            {
                tri[i * 3] = i + 2;
                tri[(i * 3) + 1] = i + 1;
                tri[(i * 3) + 2] = 0;
            }
            else
            {
                tri[i * 3] = 0;
                tri[(i * 3) + 1] = i + 1;
                tri[(i * 3) + 2] = i + 2;
            }
        }

        // Add the final triangle
        // If we're making a circle (360 degrees), we'll need to attach the last point to the first point
        if (angle == 360f)
        {
            if (facingForward)
            {
                tri[tri.Length - 3] = 1;
                tri[tri.Length - 2] = numEdgePoints;
                tri[tri.Length - 1] = 0;
            }
            else
            {
                tri[tri.Length - 3] = 0;
                tri[tri.Length - 2] = numEdgePoints;
                tri[tri.Length - 1] = 1;
            }
        }
        // Otherwise, create the last triangle as normal
        else
        {
            if (facingForward)
            {
                tri[tri.Length - 3] = 0;
                tri[tri.Length - 2] = numEdgePoints + 1;
                tri[tri.Length - 1] = numEdgePoints;
            }
            else
            {
                tri[tri.Length - 3] = numEdgePoints;
                tri[tri.Length - 2] = numEdgePoints + 1;
                tri[tri.Length - 1] = 0;
            }
        }

        wedgeMesh.vertices = vertices;
        wedgeMesh.triangles = tri;

        // RecalculateNormals helps the renderer know how to light our faces
        wedgeMesh.RecalculateNormals();

        return wedgeMesh;
    }


    /*
     * This function will create a circle mesh.
     * 
     * Parameters:
     * numEdgePoints: The number of points to create around the edge of the circle, more points means a smoother circle, but also more triangles and slower rendering
     * radius: The radius of the circle
     * facingForward: Boolean to determine which way we want the circle to face. "Forward" is towards -Z.
     * 
     * Returns:
     * circleMesh: The mesh of the new circle.
     * 
     */
    public static Mesh Create2DCircle(int numEdgePoints, float radius, bool facingForward =true)
    {
        // A circle is just a wedge covering all 360 degrees
        Mesh circleMesh = Create2DWedge(numEdgePoints, radius, 360f, facingForward);

        return circleMesh;
    }


    /*
     * This function will create a 3D wedge mesh
     * 
     * Parameters:
     * numEdgePoints: The number of points to create around the edge of the wedge, more points means a smoother wedge, but also more triangles and slower rendering
     * radius: The radius of the circle we're cutting a wedge from
     * angle: How much of a circle you want your wedge to cover in degrees. 360 degrees will create a cylinder.
     * depth: How long you want the wedge to be (How far apart the two faces should be)
     * 
     * Returns:
     * wedgeMesh: The mesh of the wedge
     * 
     */
    public static Mesh Create3DWedge(int numEdgePoints, float radius, float angle, float depth)
    {
        Mesh wedgeMesh = new Mesh();

        Mesh topWedge = Create2DWedge(numEdgePoints, radius, angle);
        Mesh bottomWedge = Create2DWedge(numEdgePoints, radius, angle, false);

        Vector3[] topWedgeVerts = topWedge.vertices;
        int[] topWedgeTri = topWedge.triangles;

        // We need to add the depth to the bottom wedge's vertices
        Vector3[] oldBottomVerts = bottomWedge.vertices;
        Vector3[] newBottomVerts = new Vector3[oldBottomVerts.Length];
        int[] bottomWedgeTri = bottomWedge.triangles;

        for (int i = 0; i < oldBottomVerts.Length; i++)
        {
            newBottomVerts[i] = oldBottomVerts[i] + new Vector3(0f, 0f, depth);
        }

        bottomWedge.vertices = newBottomVerts;

        Vector3[] cylinderVerts = new Vector3[topWedge.vertices.Length + bottomWedge.vertices.Length];
        int[] cylinderWedgeTri = new int[topWedge.triangles.Length + bottomWedge.triangles.Length];

        //Keep track of where we are in the overall cylinder lists
        int cylinderVertIndex = 0;
        int cylinderWedgeTriIndex = 0;

        // Add the top wedge's vertices
        for (int i = 0; i < topWedgeVerts.Length; i++)
        {
            cylinderVerts[cylinderVertIndex] = topWedgeVerts[i];
            cylinderVertIndex++;
        }
        // Add the top wedge's triangles
        for (int i = 0; i < topWedgeTri.Length; i++)
        {
            cylinderWedgeTri[cylinderWedgeTriIndex] = topWedgeTri[i];
            cylinderWedgeTriIndex++;
        }

        // Add the bottom wedge's vertices
        for (int i = 0; i < newBottomVerts.Length; i++)
        {
            cylinderVerts[cylinderVertIndex] = newBottomVerts[i];
            cylinderVertIndex++;
        }
        // Add the bottom wedges's triangles
        // NOTE: We need to offset the indexes, since we've added the vertices to a new, larger list
        for (int i = 0; i < bottomWedgeTri.Length; i++)
        {
            cylinderWedgeTri[cylinderWedgeTriIndex] = bottomWedgeTri[i] + topWedgeVerts.Length;
            cylinderWedgeTriIndex++;
        }

        // Now, create the tube of the cylinder
        // We won't need any new vertices, we just need new triangles to connect the top wedge to the bottom wedge
        int extraTriangles = 0;
        if (angle != 360f)
        {
            // If we're creating a cylinder, we'll only need to close the cylinder in one place (using two triangles)
            // Otherwise, we'll need to close the starting and ending edges, so we'll need an extra two triangles
            extraTriangles = 6;
        }

        int[] tubeTri = new int[(topWedgeVerts.Length * 6) + extraTriangles];

        int offset = 0;
        for (int i = 0; i < tubeTri.Length - 12 - extraTriangles; i += 6)
        {
            // Need to create rectangles for each point
            tubeTri[i] = 1 + offset;                                // First point on top wedge (not center, which is 0)
            tubeTri[i + 1] = topWedgeVerts.Length + 2 + offset;     // Second point on bottom wedge
            tubeTri[i + 2] = topWedgeVerts.Length + 1 + offset;     // First point on bottom wedge

            tubeTri[i + 3] = topWedgeVerts.Length + 2 + offset;     // Second point on bottom wedge
            tubeTri[i + 4] = 1 + offset;                            // First point on top wedge
            tubeTri[i + 5] = 2 + offset;                            // Second point on top wedge

            offset++;
        }

        // Add closing rects for cylinder
        if (angle == 360f)
        {
            // If we are making a 360 wedge (cylinder), close the cylinder using the circle's edge
            tubeTri[tubeTri.Length - 6] = topWedgeVerts.Length - 1;     // Last point on top wedge
            tubeTri[tubeTri.Length - 5] = topWedgeVerts.Length + 1;     // First point on bottom wedge
            tubeTri[tubeTri.Length - 4] = cylinderVerts.Length - 1;     // Last point on bottom wedge

            tubeTri[tubeTri.Length - 3] = topWedgeVerts.Length + 1;     // First point on bottom wedge
            tubeTri[tubeTri.Length - 2] = topWedgeVerts.Length - 1;     // Last point on top wedge
            tubeTri[tubeTri.Length - 1] = 1;                            // First point on top wedge
        }
        else
        {
            // Otherwise, we need to close the edges using the center point
            // Close starting edge
            tubeTri[tubeTri.Length - 12] = topWedgeVerts.Length + 1;     // First point on bottom wedge
            tubeTri[tubeTri.Length - 11] = topWedgeVerts.Length;         // Center point on bottom wedge
            tubeTri[tubeTri.Length - 10] = 0;                            // Center point on top wedge
            
            tubeTri[tubeTri.Length - 9] = topWedgeVerts.Length + 1;     // First point on bottom wedge
            tubeTri[tubeTri.Length - 8] = 0;                            // Center point on top wedge
            tubeTri[tubeTri.Length - 7] = 1;                            // First point on top wedge

            // Close ending edge
            tubeTri[tubeTri.Length - 6] = 0;                            // Center point on top wedge
            tubeTri[tubeTri.Length - 5] = topWedgeVerts.Length;         // Center point on bottom wedge
            tubeTri[tubeTri.Length - 4] = topWedgeVerts.Length - 1;     // Last point on top wedge
            
            tubeTri[tubeTri.Length - 3] = cylinderVerts.Length - 1 ;    // Last point on bottom wedge
            tubeTri[tubeTri.Length - 2] = topWedgeVerts.Length - 1;     // Last point on top wedge
            tubeTri[tubeTri.Length - 1] = topWedgeVerts.Length;         // Center point on bottom wedge
        }
        

        // Concatenate the wedge triangle array with the tube triangle array
        int[] cylinderAllTri = cylinderWedgeTri.Concat(tubeTri).ToArray<int>();

        wedgeMesh.vertices = cylinderVerts;
        wedgeMesh.triangles = cylinderAllTri;

        // RecalculateNormals helps the renderer know how to light our faces
        wedgeMesh.RecalculateNormals();

        return wedgeMesh;
    }


    /*
     * This function will create a cylinder mesh, by creating two circle meshes using the above Create2DCircle method, then connecting them with a tube.
     * 
     * Parameters:
     * numEdgePoints: The number of points to create around the edge of each circle, more points means a smoother circle, but also more triangles and slower rendering
     * radius: The radius of the cylinder
     * depth: How long you want the cylinder to be (How far apart the two circles should be)
     * 
     * Returns:
     * cylinderMesh: The mesh for the new cylinder
     * 
     */
    public static Mesh CreateCylinder(int numEdgePoints, float radius, float depth)
    {
        // A cylinder is just a 3D wedge covering all 360 degrees
        Mesh cylinderMesh = Create3DWedge(numEdgePoints, radius, 360f, depth);

        return cylinderMesh;
    }


    /*
     * This function creates a 2D toroid wedge mesh, using the Create2DWedge method to create the vertices of the inner and outer circles
     * 
     * Parameters:
     * numEdgePoints: The number of points to create around the edge of each circle, more points means a smoother circle, but also more triangles and slower rendering
     * innerRadius: The radius of the inner open circle
     * outerRadius: The radius of the outer boundary circle
     * angle: How much of a circle you want your wedge to cover in degrees. 360 degrees will create a circle.
     * facingForward: Boolean to determine which way we want the circle to face. "Forward" is towards -Z.
     * 
     */
    public static Mesh Create2DToroidWedge(int numEdgePoints, float innerRadius, float outerRadius, float angle, bool facingForward=true)
    {
        Mesh toroidWedgeMesh = new Mesh();

        // A toroid wedge is pretty much the same as a circle, but has a cutout in the middle
        // Thus, I'm using the Create2DWedge to create the vertices.
        // Note: This will spend time creating trangles as well, but this slowdown should hopefully be small.
        // TODO: Split out the vertices and triangles so we can just reuse the vertice creation here.

        Mesh innerCircle = Create2DWedge(numEdgePoints, innerRadius, angle, facingForward);
        Mesh outerCircle = Create2DWedge(numEdgePoints, outerRadius, angle, facingForward);

        Vector3[] innerCircleVertices = innerCircle.vertices;
        Vector3[] outerCircleVertices = outerCircle.vertices;

        Vector3[] toroidVertices = innerCircleVertices.Concat(outerCircleVertices).ToArray<Vector3>();
        int[] toroidTriangles = new int[(numEdgePoints * 6) + 6];

        int offset = 0;
        for (int i = 0; i <= numEdgePoints; i++)
        {
            if (facingForward)
            {
                toroidTriangles[offset] = i;                                     // Inner circle 1
                toroidTriangles[offset + 1] = i + 1;                             // Inner circle 2
                toroidTriangles[offset + 2] = innerCircleVertices.Length + i;    // Outer circle 1

                toroidTriangles[offset + 3] = i + 1;                                 // Inner circle 2
                toroidTriangles[offset + 4] = innerCircleVertices.Length + i + 1;    // Outer circle 2
                toroidTriangles[offset + 5] = innerCircleVertices.Length + i;        // Outer circle 1
            }
            else
            {
                toroidTriangles[offset] = innerCircleVertices.Length + i;    // Outer circle 1
                toroidTriangles[offset + 1] = i + 1;                             // Inner circle 2
                toroidTriangles[offset + 2] = i;                                     // Inner circle 1

                toroidTriangles[offset + 3] = innerCircleVertices.Length + i;        // Outer circle 1
                toroidTriangles[offset + 4] = innerCircleVertices.Length + i + 1;    // Outer circle 2
                toroidTriangles[offset + 5] = i + 1;                                 // Inner circle 2
            }
            offset+=6;
        }
        
        toroidWedgeMesh.vertices = toroidVertices;
        toroidWedgeMesh.triangles = toroidTriangles;

        // RecalculateNormals helps the renderer know how to light our faces
        toroidWedgeMesh.RecalculateNormals();

        return toroidWedgeMesh;
    }


    public static Mesh Create3DToroidWedge(int numEdgePoints, float innerRadius, float outerRadius, float angle, float depth)
    {
        Mesh toroidMesh = new Mesh();

        // Create the front and back 2D toroids
        Mesh frontToroid = Create2DToroidWedge(numEdgePoints, innerRadius, outerRadius, angle);
        Mesh backToroid = Create2DToroidWedge(numEdgePoints, innerRadius, outerRadius, angle, false);

        Vector3[] frontToroidVerts = frontToroid.vertices;
        int[] frontToroidTri = frontToroid.triangles;

        // We need to add the depth to the bottom wedge's vertices
        Vector3[] oldBottomVerts = backToroid.vertices;
        Vector3[] newBottomVerts = new Vector3[oldBottomVerts.Length];
        int[] backToroidTri = backToroid.triangles;

        for (int i = 0; i < oldBottomVerts.Length; i++)
        {
            newBottomVerts[i] = oldBottomVerts[i] + new Vector3(0f, 0f, depth);
        }

        backToroid.vertices = newBottomVerts;

        Vector3[] toroidVerts = new Vector3[frontToroidVerts.Length + newBottomVerts.Length];
        int[] toroidTri = new int[frontToroidTri.Length + backToroidTri.Length];

        //Keep track of where we are in the overall cylinder lists
        int toroidVertIndex = 0;
        int toroidWedgeTriIndex = 0;

        // Add the top wedge's vertices
        for (int i = 0; i < frontToroidVerts.Length; i++)
        {
            toroidVerts[toroidVertIndex] = frontToroidVerts[i];
            toroidVertIndex++;
        }
        // Add the top wedge's triangles
        for (int i = 0; i < frontToroidTri.Length; i++)
        {
            toroidTri[toroidWedgeTriIndex] = frontToroidTri[i];
            toroidWedgeTriIndex++;
        }

        // Add the bottom wedge's vertices
        for (int i = 0; i < newBottomVerts.Length; i++)
        {
            toroidVerts[toroidVertIndex] = newBottomVerts[i];
            toroidVertIndex++;
        }
        // Add the bottom wedges's triangles
        // NOTE: We need to offset the indexes, since we've added the vertices to a new, larger list
        for (int i = 0; i < backToroidTri.Length; i++)
        {
            toroidTri[toroidWedgeTriIndex] = backToroidTri[i] + frontToroidVerts.Length;
            toroidWedgeTriIndex++;
        }

        // Create inner tube
        int[] innerTubeTriangles = new int[numEdgePoints * 6];
        int innerOffset = 0;
        for (int i = 1; i <= numEdgePoints; i++)
        {
            innerTubeTriangles[innerOffset] = frontToroidVerts.Length + i + 1;  // Back inner circle 1
            innerTubeTriangles[innerOffset + 1] = i + 1;                        // Front inner circle 2
            innerTubeTriangles[innerOffset + 2] = i;                            // Front inner circle 1

            innerTubeTriangles[innerOffset + 3] = frontToroidVerts.Length + i;      // Back inner circle 1
            innerTubeTriangles[innerOffset + 4] = frontToroidVerts.Length + i + 1;  // Back inner circle 2
            innerTubeTriangles[innerOffset + 5] = i;                                // Front inner circle 1
            innerOffset += 6;
        }

        // Create outer tube
        int[] outerTubeTriangles = new int[numEdgePoints * 6];
        int outerOffset = 0;
        for (int i = 1; i <= numEdgePoints; i++)
        {
            outerTubeTriangles[outerOffset] = (frontToroidVerts.Length / 2) + i;                                // Front outer circle 1
            outerTubeTriangles[outerOffset + 1] = (frontToroidVerts.Length / 2) + i + 1;                        // Front outer circle 2
            outerTubeTriangles[outerOffset + 2] = frontToroidVerts.Length + (newBottomVerts.Length / 2) + i;    // Back outer circle 1

            outerTubeTriangles[outerOffset + 3] = (frontToroidVerts.Length / 2) + i + 1;                            // Front outer circle 2
            outerTubeTriangles[outerOffset + 4] = frontToroidVerts.Length + (newBottomVerts.Length / 2) + i + 1;    // Back outer circle 2
            outerTubeTriangles[outerOffset + 5] = frontToroidVerts.Length + (newBottomVerts.Length / 2) + i;        // Back outer circle 1
            outerOffset += 6;
        }


        // If we're creating a wedge (less than 360 degrees), we need to close the edge faces
        int[] closingFaces = new int[12];
        if (angle != 360)
        {
            // Close starting face
            closingFaces[0] = frontToroidVerts.Length + (newBottomVerts.Length / 2) + 1;    // Back outer circle 1
            closingFaces[1] = frontToroidVerts.Length + 1;                                  // Back inner circle 1
            closingFaces[2] = 1;                                                            // Front inner circle 1
            
            closingFaces[3] = (frontToroidVerts.Length / 2) + 1;                            // Front outer circle 1
            closingFaces[4] = frontToroidVerts.Length + (newBottomVerts.Length / 2) + 1;    // Back outer circle 1
            closingFaces[5] = 1;                                                            // Front inner circle 1
            
            // Close ending face
            closingFaces[6] = (frontToroidVerts.Length / 2) - 1; // Front inner circle last
            closingFaces[7] = toroidVerts.Length - (newBottomVerts.Length / 2) - 1; // Back inner circle last
            closingFaces[8] = toroidVerts.Length - 1; // Back outer circle last
            
            closingFaces[9] = (frontToroidVerts.Length / 2) - 1; // Front inner circle last
            closingFaces[10] = toroidVerts.Length - 1; // Back outer circle last
            closingFaces[11] = frontToroidVerts.Length - 1; // Front outer circle last
        }

        toroidMesh.vertices = toroidVerts;
        //                     Front/Back faces + Inner tube +                              Outer Tube +                              Edge Faces
        toroidMesh.triangles = toroidTri.Concat(innerTubeTriangles).ToArray<int>().Concat(outerTubeTriangles).ToArray<int>().Concat(closingFaces).ToArray<int>();

        // RecalculateNormals helps the renderer know how to light our faces
        toroidMesh.RecalculateNormals();

        return toroidMesh;
    }
    
}

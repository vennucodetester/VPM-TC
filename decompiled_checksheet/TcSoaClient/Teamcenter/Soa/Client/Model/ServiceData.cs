namespace Teamcenter.Soa.Client.Model;

public interface ServiceData
{
	int sizeOfCreatedObjects();

	int sizeOfDeletedObjects();

	int sizeOfUpdatedObjects();

	int sizeOfPlainObjects();

	int sizeOfPartialErrors();

	ModelObject GetCreatedObject(int index);

	string GetDeletedObject(int index);

	ModelObject GetUpdatedObject(int index);

	ModelObject GetPlainObject(int index);

	ErrorStack GetPartialError(int index);
}
